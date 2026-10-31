export function orderTotal(prices: number[]): number {
  const total: number = prices.reduce((sum, p) => sum + p, 0);
  const label: number = 'total';
  return total + label;
}
