using System;

namespace Common.Model
{
    public class Paging
    {
        public int PageIndex
        {
            get
            {
                if (Length == 0)
                    return 0;
                return Start / Length;
            }
        }
        public int Start { get; set; }
        public int Length { get; set; }
    }
    public class DropdownViewModel
    {
        public string key { get; set; }
        public string value { get; set; }
    }
}
