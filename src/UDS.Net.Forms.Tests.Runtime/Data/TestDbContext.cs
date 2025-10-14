using System;
using Microsoft.EntityFrameworkCore;
using UDS.Net.API.Entities;

namespace UDS.Net.Forms.Tests.Runtime.Data;

public class TestDbContext : DbContext
{
    /* Load entities from UDS.Net.API.Entities */
    public DbSet<M1> M1s { get; set; }
    public DbSet<Packet> Packets { get; set; }
    public DbSet<PacketSubmission> PacketSubmissions { get; set; }
    public DbSet<PacketSubmissionError> PacketSubmissionErrors { get; set; }

    /* Forms and instruments */
    public DbSet<A1> A1s { get; set; }
    public DbSet<A1a> A1as { get; set; }
    public DbSet<A2> A2s { get; set; }
    public DbSet<A3> A3s { get; set; }
    public DbSet<A4> A4s { get; set; }
    public DbSet<A4a> A4as { get; set; }
    public DbSet<A5D2> A5D2s { get; set; }
    public DbSet<B1> B1s { get; set; }
    public DbSet<B3> B3s { get; set; }
    public DbSet<B4> B4s { get; set; }
    public DbSet<B5> B5s { get; set; }
    public DbSet<B6> B6s { get; set; }
    public DbSet<B7> B7s { get; set; }
    public DbSet<B8> B8s { get; set; }
    public DbSet<B9> B9s { get; set; }
    public DbSet<C2> C2s { get; set; }
    public DbSet<D1a> D1as { get; set; }
    public DbSet<D1b> D1bs { get; set; }

    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configure your entities here
        modelBuilder.Entity<A3>(entity =>
        {
            entity.OwnsOne(a => a.SIB1);
            entity.OwnsOne(a => a.SIB2);
            entity.OwnsOne(a => a.SIB3);
            entity.OwnsOne(a => a.SIB4);
            entity.OwnsOne(a => a.SIB5);
            entity.OwnsOne(a => a.SIB6);
            entity.OwnsOne(a => a.SIB7);
            entity.OwnsOne(a => a.SIB8);
            entity.OwnsOne(a => a.SIB9);
            entity.OwnsOne(a => a.SIB10);
            entity.OwnsOne(a => a.SIB11);
            entity.OwnsOne(a => a.SIB12);
            entity.OwnsOne(a => a.SIB13);
            entity.OwnsOne(a => a.SIB14);
            entity.OwnsOne(a => a.SIB15);
            entity.OwnsOne(a => a.SIB16);
            entity.OwnsOne(a => a.SIB17);
            entity.OwnsOne(a => a.SIB18);
            entity.OwnsOne(a => a.SIB19);
            entity.OwnsOne(a => a.SIB20);


            entity.OwnsOne(a => a.KID1);
            entity.OwnsOne(a => a.KID2);
            entity.OwnsOne(a => a.KID3);
            entity.OwnsOne(a => a.KID4);
            entity.OwnsOne(a => a.KID5);
            entity.OwnsOne(a => a.KID6);
            entity.OwnsOne(a => a.KID7);
            entity.OwnsOne(a => a.KID8);
            entity.OwnsOne(a => a.KID9);
            entity.OwnsOne(a => a.KID10);
            entity.OwnsOne(a => a.KID11);
            entity.OwnsOne(a => a.KID12);
            entity.OwnsOne(a => a.KID13);
            entity.OwnsOne(a => a.KID14);
            entity.OwnsOne(a => a.KID15);

        });

        modelBuilder.Entity<A4a>(entity =>
        {
            entity.OwnsOne(a => a.Treatment1);
            entity.OwnsOne(a => a.Treatment2);
            entity.OwnsOne(a => a.Treatment3);
            entity.OwnsOne(a => a.Treatment4);
            entity.OwnsOne(a => a.Treatment5);
            entity.OwnsOne(a => a.Treatment6);
            entity.OwnsOne(a => a.Treatment7);
            entity.OwnsOne(a => a.Treatment8);
        });
    }
}

