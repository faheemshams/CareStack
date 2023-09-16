import { Component, OnInit } from '@angular/core';
import { IBookDetails } from '../Interfaces/app.interface';
import { BookServiceService } from '../Services/book-service.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss']
})
export class BookComponent implements OnInit
{
  public form!: IBookDetails;
  public editingMode : boolean = false;
  public editedBookId : string = '';
  public editedBook: IBookDetails | null = null;

  constructor(private router: Router, private readonly bookService: BookServiceService,
    private readonly route:ActivatedRoute)
  {}
  
  ngOnInit(): void 
  {
    this.form = {
     id : '',
     title : '',
     author : '',
     summary : '',
     notes : '',
     rating : 0
    }

    this.route.queryParams.subscribe(params => {
      const id = params['id'];

      if(id != null)
      this.bookService.getBookById(id);


    });

    


   }

   public onSubmit()
   {
      this.form.id = 'book' + Date.now();
      this.bookService.storeBook(this.form);
   }

   public onReset()
   {
      this.form = {
      id : '',
      title : '',
      author : '',
      summary : '',
      notes : '',
      rating : 0
     }
   }

   public onViewBooks()
   {
      this.router.navigate(['product']);
   }
}
