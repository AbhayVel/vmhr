using System;
using System.Collections.Generic;
using System.Text;

namespace HREntity
{
    public class Feed
    {
        public int Id { get; set; }

        public string TextData { get; set; }

        public string Heading { get; set; }

        public string ShortNotes { get; set; }

        public int FeedTypeId { get; set; }

        public string Link { get; set; }


        public string UserName { get; set; }

        public DateTime FeedDate { get; set; }

    }
}
