export interface WaterMeter {
    [x: string]: any;
    id: string;
    meterReading: number;
    isOnline: boolean;
    buildingId: string;
}