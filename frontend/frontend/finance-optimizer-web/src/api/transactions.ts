const API_URL = import.meta.env.VITE_API_URL;

export type Transaction = {
  id: string;
  bookingDate: string;
  description: string;
  amount: number;
  currency: string;
  category: string;
};

export type CreateTransactionRequest = {
  bookingDate: string;
  description: string;
  amount: number;
  currency: string;
};

export type ApiValidationError = {
  code: string;
  message: string;
};

export type ApiValidationErrorResponse = {
  errors: ApiValidationError[];
};

export async function getTransactions(): Promise<Transaction[]> {
  const response = await fetch(`${API_URL}/transactions`);

  if (!response.ok) {
    throw new Error("Could not load transactions.");
  }

  return response.json();
}

export async function createTransaction(
  request: CreateTransactionRequest
): Promise<{ id: string }> {
  const response = await fetch(`${API_URL}/transactions`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(request),
  });

  if (!response.ok) {
    throw (await response.json()) as ApiValidationErrorResponse;
  }

  return response.json();
}