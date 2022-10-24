export class Lead {
    id: string;
    firstName: string;
    lastName: string;
    dateCreated: string;
    phoneNumber: string;
    email: string;
    suburb: string;
    category: string;
    jobId: string;
    description: string;
    price: number;

    constructor(id: string, firstName: string, lastName: string, dateCreated: string, phoneNumber: string, email: string,
        suburb: string, category: string, jobId: string, description: string, price: number) {
            this.id = id,
            this.firstName = firstName,
            this.lastName = lastName,
            this.dateCreated = dateCreated,
            this.phoneNumber = phoneNumber,
            this.email = email,
            this.suburb = suburb,
            this.category = category,
            this.jobId = jobId,
            this.description = description,
            this.price = price
    }
}