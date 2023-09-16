export interface IGetUserDetails
{
        name : string,
        email : string,
        password : string,
        confirmPassword : string
}

export interface IBookDetails
{
        id? : string,
        title : string,
        author : string,
        summary : string,
        notes : string,
        rating : number
}