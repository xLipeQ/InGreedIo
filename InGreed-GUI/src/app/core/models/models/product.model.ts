import { SafeUrl } from "@angular/platform-browser";

export class ProductModel {
    id: number;
    name: string;
    description: string;
    averageOpinion: number;
    numberOfOpinions: number;
    isFavourite: boolean;
    imageData: {blob: Blob | undefined, localURL: SafeUrl | undefined};
    
    constructor(id: number = 1, name: string = '', description: string = '', rating: number = 1, numberOpinions: number = 1, isFavourite: boolean = false) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.averageOpinion = rating;
        this.numberOfOpinions = numberOpinions;
        this.isFavourite = isFavourite;
        this.imageData = {
            blob: undefined,
            localURL: undefined
        };
    }
    
}