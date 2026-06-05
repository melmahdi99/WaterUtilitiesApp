export interface Building {
    id: string;
    buildingType: string;
    streetNum: number;
    streetName: string;
    streetSuffix: string;
    zipCode: number;
    kingdomName: string;
    latitude: number;
    longitude: number;
}


export interface CreateBuildingDto {
    buildingType: string;
    streetNum: number;
    streetName: string;
    streetSuffix: string;
    zipCode: number;
    kingdomName: string;
}
