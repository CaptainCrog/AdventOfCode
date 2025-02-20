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
            var instruction = instructions[currentIndex+currentRegisterValue];
            if (instruction.Contains("dec"))
                instruction = instruction.Replace("dec", "inc");
            else if (instruction.Contains("tgl"))
                instruction = instruction.Replace("tgl", "inc");
            else if (instruction.Contains("inc"))
                instruction = instruction.Replace("inc", "dec");
            else if (instruction.Contains("jnz"))
            {
                var parts = instruction.Split(" ");
                var value = parts[2];
                parts[0] = "cpy";
                parts[2] = parts[1];
                parts[1] = value;

                instruction = string.Join(" ", parts);
            }
            else
            {
                var parts = instruction.Split(" ");
                var value = parts[1];
                parts[0] = "jnz";
                parts[1] = parts[2];
                parts[2] = value;

                instruction = string.Join(" ", parts);
            }

            instructions[currentIndex + currentRegisterValue] = instruction;
        }
    }
}
