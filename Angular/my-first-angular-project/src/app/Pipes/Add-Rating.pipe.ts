import { Pipe, PipeTransform } from "@angular/core";

@Pipe ({name : 'add-rating'})

export class AddRatingPipe implements PipeTransform
{
    transform(rating : number) : number
    {
        return rating * 2;
    }
}