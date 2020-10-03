using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.Models
{
    public partial class VideoMDContext : DbContext
    {
        public VideoMDContext()
        {
        }

        public VideoMDContext(DbContextOptions<VideoMDContext> options)
            : base(options)
        {
        }

       
      
      
        public virtual DbSet<MetaData> MetaData { get; set; }
        public virtual DbSet<MetaDataTitles> MetaDataTitles { get; set; }
        public virtual DbSet<MetaDataTypes> MetaDataTypes { get; set; }
      
       
        public virtual DbSet<Videos> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=172.17.176.211\\RTCLOCAL;Database=VideoMD;User ID=VideoTag; Password=Zaq1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {    
                
           

            modelBuilder.Entity<MetaData>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(2000);

                entity.Property(e => e.EndTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MetadataTitleId).HasColumnName("MetadataTitleID");

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VideoId).HasColumnName("VideoID");

                entity.HasOne(d => d.MetadataTitle)
                    .WithMany(p => p.MetaData)
                    .HasForeignKey(d => d.MetadataTitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MetaData_MetaDataTitles");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.MetaData)
                    .HasForeignKey(d => d.VideoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MetaData_Videos");
            });

            modelBuilder.Entity<MetaDataTitles>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(1000);

                entity.Property(e => e.Entitle)
                    .HasColumnName("ENtitle")
                    .HasMaxLength(1000);

                entity.Property(e => e.MetaDataTypeId).HasColumnName("MetaDataTypeID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.MetaDataType)
                    .WithMany(p => p.MetaDataTitles)
                    .HasForeignKey(d => d.MetaDataTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MetaDataTitles_MetaDataTypes");
            });

            modelBuilder.Entity<MetaDataTypes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

         


            modelBuilder.Entity<Videos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
