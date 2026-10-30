export function runExpression(req: { query: { code: string } }) {
  return eval(req.query.code);
}
