using System.Collections.Generic;

namespace Gimle.Core.Utils
{
    public class ReplaceValue
    {
        public bool IsInline { get; }
        public KeyValuePair<string, string> Value { get; }

        public ReplaceValue(KeyValuePair<string, string> value, bool isInline = false)
        {
            Value = value;
            IsInline = isInline;
        }
        
        public ReplaceValue(string key, string value, bool isInline = false)
        {
            Value = new KeyValuePair<string, string>(key, value);
            IsInline = isInline;
        }
    }
}