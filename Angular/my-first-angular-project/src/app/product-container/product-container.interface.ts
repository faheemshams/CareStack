export interface IProductList 
{
      id : number;
      label : string;
      price : number;
}

export interface ICategoryList
{
    CategoryId : number;
    name : string;
}

export interface IOffer
{
    OfferId : number;
    OfferName : string;
    OfferPercentage : number;
}