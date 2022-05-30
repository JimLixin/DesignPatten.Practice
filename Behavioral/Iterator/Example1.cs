using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatten.Practice.Behavioral.Iterator
{
    public class News
    {
        private string _content;

        public News(string content)
        {
            this._content = content;
        }

        public string GetContent()
        {
            return this._content;
        }
    }

    public interface Iterator
    {
        bool HasNext();

        News Next();
    }

    
}
