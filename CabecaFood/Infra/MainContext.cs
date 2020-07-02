﻿using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<DeliveryMan> DeliveryMan { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Order_Snack> Order_Snack { get; set; }
        public DbSet<Snack> Snack { get; set; }
        public DbSet<Snack_Ingredient> Snack_Ingredient { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Aprendizagem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
    }
}