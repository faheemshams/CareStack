"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Database = /** @class */ (function () {
    function Database(databaseName) {
        this.databaseName = databaseName;
        this.indexedDB = window.indexedDB || window.webkitIndexedDB;
        if (!this.indexedDB) {
            console.log("IndexedDB could not be found in this browser.");
        }
    }
    Database.getInstance = function (databaseName) {
        if (!Database.instance) {
            Database.instance = new Database(databaseName);
        }
        return Database.instance;
    };
    Database.prototype.openDatabase = function () {
        if (!this.indexedDB) {
            console.log("IndexedDB not available.");
            return undefined;
        }
        var request = this.indexedDB.open(this.databaseName, 1);
        request.onerror = function (event) {
            console.error("An error occurred with IndexedDB");
            console.error(event);
            request.onupgradeneeded = function (event) {
                var db = event.target.result;
                if (!db.objectStoreNames.contains("students")) {
                    db.createObjectStore("students", { keyPath: "id", autoIncrement: true });
                }
            };
            return request;
        };
    };
    Database.instance = null;
    return Database;
}());
exports.default = Database;
