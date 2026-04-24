using FinanceOptimizer.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceOptimizer.Infrastructure.Persistence.Configurations;

/// <summary>
/// Entity Framework configuration for the Transaction aggregate.
/// </summary>
public sealed class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    /// <summary>
    /// Configures the transaction table mapping.
    /// </summary>
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("transactions");

        builder.HasKey(transaction => transaction.Id);

        builder.Property(transaction => transaction.Id)
            .HasColumnName("id");

        builder.Property(transaction => transaction.BookingDate)
            .HasColumnName("booking_date")
            .IsRequired();

        builder.Property(transaction => transaction.Description)
            .HasColumnName("description")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(transaction => transaction.Category)
            .HasColumnName("category")
            .HasConversion<string>()
            .HasMaxLength(100)
            .IsRequired();

        builder.OwnsOne(transaction => transaction.Amount, money =>
        {
            money.Property(value => value.Amount)
                .HasColumnName("amount")
                .HasPrecision(18, 2)
                .IsRequired();

            money.Property(value => value.Currency)
                .HasColumnName("currency")
                .HasMaxLength(3)
                .IsRequired();
        });
    }
}