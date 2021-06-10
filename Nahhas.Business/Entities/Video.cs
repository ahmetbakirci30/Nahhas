using Nahhas.Business.Entities.Base;

namespace Nahhas.Business.Entities
{
    public class Video : StatusBase
    {
        public string Title { get; set; }
        public string VideoPath { get; set; }
        public string CoverPath { get; set; }
    }
}