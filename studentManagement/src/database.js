class Database 
{
    constructor(databaseName) 
    {
      if(!Database.instance)
      Database.instance = this;
      else
      return Database.instance;
      
      this.databaseName = databaseName;
      this.indexedDB = window.indexedDB || window.webkitIndexedDB ;
      if (!this.indexedDB) 
      {
        console.log("IndexedDB could not be found in this browser.");
      }
    }
  
    openDatabase() 
    {
      if (!this.indexedDB) 
      {
        console.log("IndexedDB not available.");
        return;
      }
  
      const request = this.indexedDB.open(this.databaseName, 1);
  
      request.onerror = function (event) {
        console.error("An error occurred with IndexedDB");
        console.error(event);
      };
  
      request.onupgradeneeded = function (event) {
        const db = event.target.result;
  
        if (!db.objectStoreNames.contains("students")) {
          db.createObjectStore("students", { keyPath: "id", autoIncrement: true });
        }
      };
      return request;
    }
}

export default Database;