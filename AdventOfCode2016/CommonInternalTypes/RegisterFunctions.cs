using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.CommonInternalTypes
{
    public static class RegisterFunctions
    {
        public static void Copy(string copy, string register, ref Dictionary<string, int> registers)
        {
            if (int.TryParse(copy, out int copyValue))
                registers[register] = copyValue;
            else
            {
                copyValue = registers[copy];
                registers[register] = copyValue;
            }
        }

        public static void Increase(string register, ref Dictionary<string, int> registers)
        {
            registers[register]++;
        }
        public static void IncreaseMult(string register, ref Dictionary<string, int> registers)
        {
            registers[register] *= registers[register];
        }

        public static void Decrease(string register, ref Dictionary<string, int> registers)
        {
            registers[register]--;
        }

        public static int Jump(string register, int jumpMovement, int currentIndex, ref Dictionary<string, int> registers)
        {
            if (!int.TryParse(register, out int value))
            {
                if (registers[register] == 0)
                    return currentIndex;
                else
                    return currentIndex + jumpMovement - 1;
            }
            else
            {
                if (value == 0)
                    return currentIndex;
                else
                    return currentIndex + jumpMovement - 1;
            }
        }

        public static void Toggle(string register, int currentIndex, ref string[] instructions, Dictionary<string, int> registers)
        {
            var currentRegisterValue = registers[register];
            if (currentIndex + currentRegisterValue >= instructions.Length)
                return;

            var instruction = instructions[currentIndex+currentRegisterValue];
            if (instruction.Contains("dec"))
                instruction = instruction.Replace("dec", "inc");
            else if (instruction.Contains("tgl"))
                instruction = instruction.Replace("tgl", "inc");
            else if (instruction.Contains("inc"))
                instruction = instruction.Replace("inc", "dec");
            else if (instruction.Contains("jnz"))
                instruction = instruction.Replace("jnz", "cpy");
            else
                instruction = instruction.Replace("cpy", "jnz");

            instructions[currentIndex + currentRegisterValue] = instruction;
        }

        public static bool OptimizeMultiplication(int index, string[] instructions, ref Dictionary<string, int> registers, out int newIndex)
        {
            newIndex = index;

            if (index + 6 >= instructions.Length)
                return false;

            var instr1 = instructions[index].Split(" ");
            var instr2 = instructions[index + 1].Split(" ");
            var instr3 = instructions[index + 2].Split(" ");
            var instr4 = instructions[index + 3].Split(" ");
            var instr5 = instructions[index + 4].Split(" ");
            var instr6 = instructions[index + 5].Split(" ");

            // Pattern: cpy b c | inc a | dec c | jnz c -2 | dec d | jnz d -5
            if (instr1[0] == "cpy" && instr2[0] == "inc" && instr3[0] == "dec" &&
                instr4[0] == "jnz" && instr5[0] == "dec" && instr6[0] == "jnz")
            {
                string source = instr1[1];
                string target = instr2[1];
                string decrementingVar = instr3[1];
                string outerLoopVar = instr5[1];

                if (instr4[1] != decrementingVar || instr4[2] != "-2")
                    return false;

                if (instr6[1] != outerLoopVar || instr6[2] != "-5")
                    return false;

                if (!registers.ContainsKey(target) || !registers.ContainsKey(decrementingVar) || !registers.ContainsKey(outerLoopVar))
                    return false;

                int sourceValue = int.TryParse(source, out int val) ? val : registers[source];
                int decrementingValue = registers[decrementingVar];
                int outerLoopValue = registers[outerLoopVar];

                // The loop effectively does: a += b * d;
                registers[target] += sourceValue * outerLoopValue;
                registers[decrementingVar] = 0;
                registers[outerLoopVar] = 0;

                newIndex = index + 5; // Skip processed loop
                return true;
            }

            return false;
        }

        public static bool Output(string register, ref string currentSignal, Dictionary<string, int> registers)
        {
            var outputValue = registers[register];

            if (outputValue > 1)
                return false;
            if (string.IsNullOrEmpty(currentSignal) && outputValue != 0)
                return false;
            // 0101|0 == 0 / 01010|1 == 1
            if (!string.IsNullOrEmpty(currentSignal) && int.Parse(currentSignal.Last().ToString()) == outputValue)
                return false;

            currentSignal += outputValue.ToString();

            return true;
        }
    }
}
