﻿namespace Khala.EventSourcing.Sql
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UniqueIndexedProperty
    {
        public const string IndexName = "SqlEventStore_IX_AggregateId_PropertyName";

        [Key]
        [Column(Order = 0)]
        [StringLength(128)]
        public string AggregateType { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(128)]
#if NETSTANDARD2_0
#else
        [Index(IndexName, IsUnique = true, Order = 1)]
#endif
        public string PropertyName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(128)]
        public string PropertyValue { get; set; }

#if NETSTANDARD2_0
#else
        [Index(IndexName, IsUnique = true, Order = 0)]
#endif
        public Guid AggregateId { get; set; }

        [ConcurrencyCheck]
        public int Version { get; set; }
    }
}
