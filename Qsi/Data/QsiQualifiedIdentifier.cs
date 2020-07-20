﻿using System;
using System.Collections.Generic;
using System.Linq;
using Qsi.Utilities;

namespace Qsi.Data
{
    public sealed class QsiQualifiedIdentifier
    {
        public QsiIdentifier this[int index] => _identifiers[index];

        public QsiIdentifier this[Index index] => _identifiers[index];

        public QsiIdentifier[] this[Range range] => _identifiers[range];

        public int Level { get; }

        private readonly QsiIdentifier[] _identifiers;

        public QsiQualifiedIdentifier(IEnumerable<QsiIdentifier> identifiers) : this(identifiers.ToArray())
        {
        }

        public QsiQualifiedIdentifier(params QsiIdentifier[] identifiers)
        {
            _identifiers = identifiers;
            Level = _identifiers?.Length ?? 0;
        }

        public override int GetHashCode()
        {
            return HashCodeUtility.Combine(_identifiers.Select(i => i.GetHashCode()));
        }

        public override string ToString()
        {
            return string.Join(".", _identifiers.Select(x => x.Value));
        }
    }
}
