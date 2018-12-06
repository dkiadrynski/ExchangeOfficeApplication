﻿// <auto-generated />
using System;
using DataSourceAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataSourceAccess.Migrations
{
    [DbContext(typeof(ExchangeOfficeContext))]
    partial class ExchangeOfficeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("DataSourceAccess.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountTypeValue");

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("Password");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DataSourceAccess.CurrencyExchange", b =>
                {
                    b.Property<int>("CurrencyExchangeId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("ActualStatus");

                    b.Property<int>("ContributedCurrencyValue");

                    b.Property<decimal>("Rate");

                    b.Property<int>("TargetCurrencyValue");

                    b.HasKey("CurrencyExchangeId");

                    b.ToTable("CurrencyExchanges");
                });

            modelBuilder.Entity("DataSourceAccess.Custumer", b =>
                {
                    b.Property<int>("CustumerId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("DailyLimit");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("CustumerId");

                    b.ToTable("Custumers");
                });

            modelBuilder.Entity("DataSourceAccess.Date", b =>
                {
                    b.Property<int>("DateId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.HasKey("DateId");

                    b.ToTable("Dates");
                });

            modelBuilder.Entity("DataSourceAccess.Exchange", b =>
                {
                    b.Property<int>("ExchangeId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ContributedAmount");

                    b.Property<int>("CurrencyExchangeId");

                    b.Property<int>("CustumerId");

                    b.Property<int>("DateId");

                    b.Property<decimal>("IssuedAmount");

                    b.HasKey("ExchangeId");

                    b.HasIndex("CurrencyExchangeId");

                    b.HasIndex("CustumerId");

                    b.HasIndex("DateId");

                    b.ToTable("Exchanges");
                });

            modelBuilder.Entity("DataSourceAccess.Exchange", b =>
                {
                    b.HasOne("DataSourceAccess.CurrencyExchange", "CurrencyExchange")
                        .WithMany("HistoryOfExchanges")
                        .HasForeignKey("CurrencyExchangeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataSourceAccess.Custumer", "Custumer")
                        .WithMany("HistoryOfExchanges")
                        .HasForeignKey("CustumerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataSourceAccess.Date", "Date")
                        .WithMany("HistoryOfExchanges")
                        .HasForeignKey("DateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
