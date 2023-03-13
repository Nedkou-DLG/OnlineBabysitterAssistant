export interface AddActivityModel{
    childId: number,
    time: Date,
    description: string
}

export interface ActivityModel{
    id: number,
    time: Date | string,
    description: string
}