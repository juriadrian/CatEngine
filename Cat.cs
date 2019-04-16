using System;
using System.Collections.Generic;

namespace catEngine
{
    public abstract class Cat
    {
        public List<string> Months;
        public virtual bool CanHandle(string month)
        {
            return Months.Contains(month);
        }
        public abstract string Handle();
        //comment
    }

    public class Persian : Cat
    {
        public Persian()
        {
            this.Months = new List<string>(){
                "JAN", "FEB", "MAR", "APR"
            };
        }

        public override string Handle()
        {
            var subtitle = "<h2>This is your kitty</h2>";
            return subtitle + "<img border='3' src='https://vetstreet.brightspotcdn.com/dims4/default/303f54d/2147483647/thumbnail/645x380/quality/90/?url=https%3A%2F%2Fvetstreet-brightspot.s3.amazonaws.com%2F29%2Fb6%2Ff4a864144d09974dfe5bf0513e20%2FPersian-AP-V8HE5B-645sm3614.jpg'>";
        }
    }

    public class European : Cat
    {
        public European()
        {
            this.Months = new List<string>(){
                "MAY", "JUN", "JUL", "AUG"
            };
        }

        public override string Handle()
        {
            var subtitle = "<h2>This is your kitty</h2>";
            return subtitle + "<img border='3' src='https://upload.wikimedia.org/wikipedia/commons/thumb/1/14/Gatto_europeo4.jpg/250px-Gatto_europeo4.jpg'>";
        }
    }

    public class IrishFold : Cat
    {
        public IrishFold()
        {
            this.Months = new List<string>(){
                "SEP", "OCT", "NOV", "DIC"
            };
        }

        public override string Handle()
        {
            var subtitle = "<h2>This is your kitty</h2>";
            return subtitle + "<img border='3' src='http://www.catbreedslist.com/uploads/allimg/cat-pictures/Scottish-Fold-2.jpg'>";
        }
    }
}
