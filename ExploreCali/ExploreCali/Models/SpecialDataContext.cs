using System;
using System.Collections.Generic;

namespace ExploreCali.Models
{

    public class Special
    {
        public string Key { get; internal set; }
        public string Name { get; internal set; }
        public string Type { get; internal set; }
        public int Price { get; internal set; }
    }
    public class SpecialDataContext
    {
        public IEnumerable<Special> GetMonthlySpecial()
        {
            return new[]
            {
                new Special{
                    Key = "abc",
                    Name ="gaurav",
                    Type = "zxy",
                    Price = 12333
                },
                new Special{
                    Key = "abc",
                    Name ="xyz",
                    Type = "zxy",
                    Price = 9089
                },
                new Special{
                    Key = "abc",
                    Name ="pqr",
                    Type = "zxy",
                    Price = 54567
                }
            };
        }
    }
}
