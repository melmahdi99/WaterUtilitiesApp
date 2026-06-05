export interface Billing {
    id: string,
    priceRate: number,
    totalAmountDue: number,
    dueDate: string,
    timePaid: string,
    isPaid: boolean,
    customerId: string,
    waterMeterId: string
}