using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace LSD_CORP;

public partial class DbContext : DbContext
{
    public DbContext()
    {
    }

    public DbContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BooksUser> BooksUsers { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=192.168.200.13;user=student;password=student;database=_db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.39-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("authors");

            entity.HasIndex(e => e.IdCountry, "FK_authors_countries_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdCountry)
                .HasColumnType("int(11)")
                .HasColumnName("id_country");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(255)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("surname");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Authors)
                .HasForeignKey(d => d.IdCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_authors_countries_id");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.IdAuthor, "FK_book_authors_id");

            entity.HasIndex(e => e.IdGenre, "FK_books_genres_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("'0868-05-11'")
                .HasColumnName("date_create");
            entity.Property(e => e.IdAuthor)
                .HasColumnType("int(11)")
                .HasColumnName("id_author");
            entity.Property(e => e.IdGenre)
                .HasColumnType("int(11)")
                .HasColumnName("id_genre");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("title");

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_book_authors_id");

            entity.HasOne(d => d.IdGenreNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdGenre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_books_genres_id");
        });

        modelBuilder.Entity<BooksUser>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.IdBook, "FK_BooksUsers_books_id");

            entity.HasIndex(e => e.IdUser, "FK_BooksUsers_users_id");

            entity.Property(e => e.IdBook)
                .HasColumnType("int(11)")
                .HasColumnName("id_book");
            entity.Property(e => e.IdUser)
                .HasColumnType("int(11)")
                .HasColumnName("id_user");

            entity.HasOne(d => d.IdBookNavigation).WithMany()
                .HasForeignKey(d => d.IdBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BooksUsers_books_id");

            entity.HasOne(d => d.IdUserNavigation).WithMany()
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BooksUsers_users_id");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("countries");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("genres");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AccessLevel)
                .HasColumnType("int(11)")
                .HasColumnName("access_level");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.IdRole, "FK_users_roles_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdRole)
                .HasColumnType("int(11)")
                .HasColumnName("id_role");
            entity.Property(e => e.Nickname)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("nickname");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("password");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_roles_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
