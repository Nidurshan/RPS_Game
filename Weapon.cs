namespace RPS_Game
{
    public class Weapon
    {

        private readonly Dictionary<string, string[]> rules = new Dictionary<string, string[]>
        {
            { "rock", new string[2] { "paper", "scissor" } },
            { "paper", new string[2] { "scissor", "rock" } },
            { "scissor", new string[2] { "rock", "paper" } }
        };

        private readonly Dictionary<string, string> codes = new Dictionary<string, string>
        {
            { "rock", "R" },
            { "paper", "P" },
            { "scissor", "S" }
        };

        public string Name { get; set; }
        public string Code { get; set; }
        public string Superior { get; set; } 
        public string Inferior { get; set; }

        public Weapon(string name)
        {
            Name = name;
            Code = codes[name];
            Superior = rules[name][0];
            Inferior = rules[name][1];

            //Console.WriteLine($"{Name}({Code}) is \nsuperior to {Superior}({codes[Superior]}) and \ninferior to {Inferior}({codes[Inferior]})");
        }
    }
}

