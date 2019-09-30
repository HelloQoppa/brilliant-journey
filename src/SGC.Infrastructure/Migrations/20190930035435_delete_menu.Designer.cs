﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGC.Infrastructure.Data;

namespace SGC.Infrastructure.Migrations
{
    [DbContext(typeof(ClienteContext))]
    [Migration("20190930035435_delete_menu")]
    partial class delete_menu
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SGC.AppCore.Entity.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("SGC.AppCore.Entity.Contato", b =>
                {
                    b.Property<int>("ContatoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(15)");

                    b.HasKey("ContatoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("SGC.AppCore.Entity.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<int>("ClienteId");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Referencia")
                        .HasColumnType("varchar(400)");

                    b.HasKey("EnderecoId");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("SGC.AppCore.Entity.Profissao", b =>
                {
                    b.Property<int>("ProfissaoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CBO")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(400)");

                    b.HasKey("ProfissaoId");

                    b.ToTable("Profissao");
                });

            modelBuilder.Entity("SGC.AppCore.Entity.ProfissaoCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<int>("ProfissaoId");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProfissaoId");

                    b.ToTable("ProfissaoCliente");
                });

            modelBuilder.Entity("SGC.AppCore.Entity.Contato", b =>
                {
                    b.HasOne("SGC.AppCore.Entity.Cliente", "Cliente")
                        .WithMany("Contatos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SGC.AppCore.Entity.Endereco", b =>
                {
                    b.HasOne("SGC.AppCore.Entity.Cliente", "Cliente")
                        .WithOne("Endereco")
                        .HasForeignKey("SGC.AppCore.Entity.Endereco", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SGC.AppCore.Entity.ProfissaoCliente", b =>
                {
                    b.HasOne("SGC.AppCore.Entity.Cliente", "Cliente")
                        .WithMany("ProfissoesClientes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SGC.AppCore.Entity.Profissao", "Profissao")
                        .WithMany("ProfissoesClientes")
                        .HasForeignKey("ProfissaoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}