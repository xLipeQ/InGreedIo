export interface ProductRequest {
    Id?: number;
    OnlyFavourite: boolean;
    Category?: number;
    SearchPhrase?: string;
    Ingredients?: number[];
    PageNumber: number;
    NormalNumber: number;
    PromotionNumber: number;
  }