class Database 
{
    private static instance: Database | null = null;
    private databaseName: string;
    private indexedDB: IDBFactory | undefined;

    public constructor(databaseName: string) 
    {
        this.databaseName = databaseName;
        this.indexedDB = window.indexedDB || (window as any).webkitIndexedDB;
        if (!this.indexedDB) 
        {
          console.log("IndexedDB could not be found in this browser.");
        }
    }

    public static getInstance(databaseName: string): Database 
    {
        if (!Database.instance) 
        {
            Database.instance = new Database(databaseName);
        }
        return Database.instance;
    }

    public openDatabase(): IDBRequest<IDBDatabase> | undefined 
    {
        if (!this.indexedDB) 
        {
          console.log("IndexedDB not available.");
          return undefined;
        }

        const request = this.indexedDB.open(this.databaseName, 1);

        request.onerror = (event) => {
        console.error("An error occurred with IndexedDB");
        console.error(event);

        request.onupgradeneeded = (event) => 
        {
            const db = (event.target as IDBOpenDBRequest).result;
            if (!db.objectStoreNames.contains("students")) 
            {
              db.createObjectStore("students", { keyPath: "id", autoIncrement: true });
            }
        };
             return request;
        }
      }
}

export default Database;