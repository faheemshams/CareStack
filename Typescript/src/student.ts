class Student 
{
    public id: number;

    constructor(
      public name: string,
      public age: number,
      public studentClass: string,
      public address: string
    ) {
        this.id = 0;
    }
  }
  
  export default Student;