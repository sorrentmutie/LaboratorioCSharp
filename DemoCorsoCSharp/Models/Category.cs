﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using DemoCorsoCSharp.Infrastructure;
using System;
using System.Collections.Generic;

namespace DemoCorsoCSharp.Models;

public partial class Category: IEntity<int>
{
    public int Id { get; set; }

    public string CategoryName { get; set; }

    public string Description { get; set; }

    public byte[] Picture { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    //public int Id { get ; set; }
}