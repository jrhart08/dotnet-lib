using System;
using System.Collections;

namespace TaskUtils.Exceptions
{
    [Serializable]
    class DuplicateEntriesException : Exception
    {
        public IEnumerable OffendingCollection { get; private set; }

        const string DEFAULT_MESSAGE = "Duplicate entries found.";

        public DuplicateEntriesException() : base(DEFAULT_MESSAGE) { }

        public DuplicateEntriesException(IEnumerable offendingCollection)
            : base(FormatMessage(offendingCollection))
        {
            OffendingCollection = offendingCollection;
        }

        static string FormatMessage(IEnumerable offendingCollection) =>
            $"Duplicate entries found: {offendingCollection}";
    }
}
