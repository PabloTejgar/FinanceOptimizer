import { FormEvent, useEffect, useState } from "react";
import {
  createTransaction,
  getTransactions,
} from "./api/transactions";

import type {
  ApiValidationError,
  Transaction,
} from "./api/transactions";
import "./App.css";

function App() {
  const [transactions, setTransactions] = useState<Transaction[]>([]);
  const [bookingDate, setBookingDate] = useState("2026-04-24");
  const [description, setDescription] = useState("");
  const [amount, setAmount] = useState("-10");
  const [currency, setCurrency] = useState("EUR");
  const [errors, setErrors] = useState<ApiValidationError[]>([]);
  const [isLoading, setIsLoading] = useState(false);

  async function loadTransactions() {
    const data = await getTransactions();
    setTransactions(data);
  }

  useEffect(() => {
    loadTransactions();
  }, []);

  async function handleSubmit(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();

    setErrors([]);
    setIsLoading(true);

    try {
      await createTransaction({
        bookingDate,
        description,
        amount: Number(amount),
        currency,
      });

      setDescription("");
      setAmount("-10");

      await loadTransactions();
    } catch (error) {
      const validationError = error as { errors?: ApiValidationError[] };
      setErrors(validationError.errors ?? [
        {
          code: "unexpected_error",
          message: "Unexpected error creating transaction.",
        },
      ]);
    } finally {
      setIsLoading(false);
    }
  }

  return (
    <main className="page">
      <section className="card">
        <h1>Finance Optimizer</h1>
        <p className="subtitle">Personal transactions prototype</p>

        <form onSubmit={handleSubmit} className="form">
          <label>
            Booking date
            <input
              type="date"
              value={bookingDate}
              onChange={(event) => setBookingDate(event.target.value)}
            />
          </label>

          <label>
            Description
            <input
              value={description}
              onChange={(event) => setDescription(event.target.value)}
              placeholder="Mercadona"
            />
          </label>

          <label>
            Amount
            <input
              type="number"
              step="0.01"
              value={amount}
              onChange={(event) => setAmount(event.target.value)}
            />
          </label>

          <label>
            Currency
            <input
              value={currency}
              onChange={(event) => setCurrency(event.target.value)}
              placeholder="EUR"
              maxLength={3}
            />
          </label>

          <button type="submit" disabled={isLoading}>
            {isLoading ? "Saving..." : "Add transaction"}
          </button>
        </form>

        {errors.length > 0 && (
          <div className="errors">
            {errors.map((error) => (
              <p key={error.code}>{error.message}</p>
            ))}
          </div>
        )}
      </section>

      <section className="card">
        <h2>Transactions</h2>

        {transactions.length === 0 ? (
          <p className="empty">No transactions yet.</p>
        ) : (
          <ul className="transactions">
            {transactions.map((transaction) => (
              <li key={transaction.id}>
                <div>
                  <strong>{transaction.description}</strong>
                  <span>{transaction.bookingDate}</span>
                </div>
                <strong>
                  {transaction.amount} {transaction.currency}
                </strong>
              </li>
            ))}
          </ul>
        )}
      </section>
    </main>
  );
}

export default App;