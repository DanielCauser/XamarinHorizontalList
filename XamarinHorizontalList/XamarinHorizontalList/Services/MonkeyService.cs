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
                Image = "common_marmoset.jpg"
            },
            new Monkey
            {
                Name = "Gibbon",
                Image = "gibbon_information.jpg"
            },
            new Monkey
            {
                Name = "Proboscis",
                Image = "Proboscis_monkey.jpg"
            },
            new Monkey
            {
                Name = "Pygmy",
                Image = "pygmy.jpg"
            },
            new Monkey
            {
                Name = "Spider",
                Image = "spider_monkey.jpg"
            },
            new Monkey
            {
                Name = "Squirrel Monkey",
                Image = "squirrel_monkey_species.jpg"
            },
            new Monkey
            {
                Name = "Tamarin",
                Image = "Tamarin.jpg"
            },
            new Monkey
            {
                Name = "Uknown",
                Image = "types_of_monkeys.jpg"
            },
            new Monkey
            {
                Name = "Vervet",
                Image = "vervet_specie.jpg"
            }
        };

        public async Task<IEnumerable<Monkey>> GetMonkey()
        {
            await Task.Delay(500);

            return Monkeys;
        }
    }
}
