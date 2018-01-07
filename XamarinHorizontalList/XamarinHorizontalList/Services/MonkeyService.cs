using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinHorizontalList.Models;

namespace XamarinHorizontalList.Services
{
    public class MonkeyService : IMonkeyService
    {
        private static List<Monkey> Monkeys = new List<Monkey>
        {
            new Monkey
            {
                Name = "Common Marmoset",
                Image = "common_marmoset"
            },
            new Monkey
            {
                Name = "Gibbon",
                Image = "gibbon_information"
            },
            new Monkey
            {
                Name = "Proboscis",
                Image = "Proboscis_monkey"
            },
            new Monkey
            {
                Name = "Pygmy",
                Image = "pygmy"
            },
            new Monkey
            {
                Name = "Spider",
                Image = "spider_monkey"
            },
            new Monkey
            {
                Name = "Squirrel Monkey",
                Image = "squirrel_monkey_species"
            },
            new Monkey
            {
                Name = "Tamarin",
                Image = "Tamarin"
            },
            new Monkey
            {
                Name = "Uknown",
                Image = "types_of_monkeys"
            },
            new Monkey
            {
                Name = "Vervet",
                Image = "vervet_specie"
            }
        };

        public async Task<IEnumerable<Monkey>> GetMonkey()
        {
            await Task.Delay(500);

            return Monkeys;
        }
    }
}
