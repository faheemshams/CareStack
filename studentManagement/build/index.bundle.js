(()=>{"use strict";var n={150:(n,e,t)=>{t.d(e,{Z:()=>c});var o=t(81),r=t.n(o),a=t(645),d=t.n(a)()(r());d.push([n.id,"header \n{\n    display: flex;\n    justify-content: space-between;\n    align-items: center;\n    background-color: #a0d2eb; \n    padding: 20px 20px;\n    font-size: 20px;                  \n}\n\n.navbar\n{\n    color: #fff;\n    font-size: 1.5rem;\n    font-weight: bold;\n}\n\nbody {\n    font-family: Arial, sans-serif;\n    background-color: #e5eaf5;\n    color: #333; \n}\n\n\n#add-student-btn\n{\n    display: inline-block;\n    padding: 10px 20px;\n    background-color: #337ab7;\n    color: #f8f8f8; \n    font-size: 16px;\n    border: none;\n    border-radius: 5px;\n    cursor: pointer;\n    text-align: center;\n    text-decoration: none;\n}\n\n#add-student-btn:hover \n{\n    background-color: #27669d;\n}\n\n.container \n{\n    text-align: center;\n    margin-top: 70px;\n}\n\ntable \n{\n    width: 80%; \n    margin: 0 auto;\n    border-collapse: collapse; \n}\n\nth, td \n{\n    padding: 10px; \n    border: 1px solid #ccc;\n}\n\nth \n{\n    background-color: hsl(208, 69%, 60%); \n    color: #fff;\n}\n\ntr\n{\n    background-color: rgba(172, 214, 250, 0.568);\n}\n\ntr:nth-child(even) \n{\n    background-color: #d5edff; \n}\n\n.modal-container {\n\n    display: flex;\n    justify-content: center;\n    align-items: center;\n    position: fixed;\n    top: 0;\n    left: 0;\n    width: 100%;\n    height: 100%;\n    background-color: rgba(0, 0, 0, 0.5);\n    z-index: 1;\n}\n\n.modal-content {\n   \n    background-color: white;\n    border: 1px solid #ddd;\n    border-radius: 15px;\n    width: 450px;\n    padding: 1.3rem;\n}\n\n#modal-title, hr\n{\n    margin-bottom : 20px;\n}\n\n.form-input \n{\n    display: flex;\n    flex-direction: column;\n    margin-bottom: 10px; \n}\n\n.form-input label \n{\n    font-weight: bold;\n    margin-bottom: 5px;\n}\n\n.form-input input \n{\n    padding: 0.7rem 1rem;\n    border: 1px solid #ddd;\n    border-radius: 5px;\n    font-size: 0.9em;\n}\n\n\n.modal-buttons \n{\n    display: flex;\n    justify-content: space-between;\n    margin-top: 20px; \n}\n\n#deleteModal\n {\n    display: none;\n    position: fixed;\n    top: 0;\n    left: 0;\n    width: 100%;\n    height: 100%;\n    background-color: rgba(0, 0, 0, 0.5); \n    z-index: 999; \n}\n\n#delete-modal-content\n{\n    background-color: white;\n    border-radius: 5px;\n    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);\n    width: 400px;\n    position: absolute;\n    top: 50%; \n    left: 50%;\n    transform: translate(-50%, -50%); \n    padding: 20px;\n    text-align: center;\n}\n\n.modal-actions {\n    margin-top: 20px;\n}\n\nbutton {\n    cursor: pointer;\n    border: none;\n    font-weight: 600;\n    padding: 10px 20px;\n}\n\n#confirmDeleteBtn {\n    background-color: #d9534f; \n    color: white;\n    margin-right: 10px;\n}\n\n#cancelDeleteBtn {\n    background-color: #337ab7; \n    color: white;\n}",""]);const c=d},645:n=>{n.exports=function(n){var e=[];return e.toString=function(){return this.map((function(e){var t="",o=void 0!==e[5];return e[4]&&(t+="@supports (".concat(e[4],") {")),e[2]&&(t+="@media ".concat(e[2]," {")),o&&(t+="@layer".concat(e[5].length>0?" ".concat(e[5]):""," {")),t+=n(e),o&&(t+="}"),e[2]&&(t+="}"),e[4]&&(t+="}"),t})).join("")},e.i=function(n,t,o,r,a){"string"==typeof n&&(n=[[null,n,void 0]]);var d={};if(o)for(var c=0;c<this.length;c++){var s=this[c][0];null!=s&&(d[s]=!0)}for(var i=0;i<n.length;i++){var l=[].concat(n[i]);o&&d[l[0]]||(void 0!==a&&(void 0===l[5]||(l[1]="@layer".concat(l[5].length>0?" ".concat(l[5]):""," {").concat(l[1],"}")),l[5]=a),t&&(l[2]?(l[1]="@media ".concat(l[2]," {").concat(l[1],"}"),l[2]=t):l[2]=t),r&&(l[4]?(l[1]="@supports (".concat(l[4],") {").concat(l[1],"}"),l[4]=r):l[4]="".concat(r)),e.push(l))}},e}},81:n=>{n.exports=function(n){return n[1]}},379:n=>{var e=[];function t(n){for(var t=-1,o=0;o<e.length;o++)if(e[o].identifier===n){t=o;break}return t}function o(n,o){for(var a={},d=[],c=0;c<n.length;c++){var s=n[c],i=o.base?s[0]+o.base:s[0],l=a[i]||0,u="".concat(i," ").concat(l);a[i]=l+1;var p=t(u),f={css:s[1],media:s[2],sourceMap:s[3],supports:s[4],layer:s[5]};if(-1!==p)e[p].references++,e[p].updater(f);else{var m=r(f,o);o.byIndex=c,e.splice(c,0,{identifier:u,updater:m,references:1})}d.push(u)}return d}function r(n,e){var t=e.domAPI(e);return t.update(n),function(e){if(e){if(e.css===n.css&&e.media===n.media&&e.sourceMap===n.sourceMap&&e.supports===n.supports&&e.layer===n.layer)return;t.update(n=e)}else t.remove()}}n.exports=function(n,r){var a=o(n=n||[],r=r||{});return function(n){n=n||[];for(var d=0;d<a.length;d++){var c=t(a[d]);e[c].references--}for(var s=o(n,r),i=0;i<a.length;i++){var l=t(a[i]);0===e[l].references&&(e[l].updater(),e.splice(l,1))}a=s}}},569:n=>{var e={};n.exports=function(n,t){var o=function(n){if(void 0===e[n]){var t=document.querySelector(n);if(window.HTMLIFrameElement&&t instanceof window.HTMLIFrameElement)try{t=t.contentDocument.head}catch(n){t=null}e[n]=t}return e[n]}(n);if(!o)throw new Error("Couldn't find a style target. This probably means that the value for the 'insert' parameter is invalid.");o.appendChild(t)}},216:n=>{n.exports=function(n){var e=document.createElement("style");return n.setAttributes(e,n.attributes),n.insert(e,n.options),e}},565:(n,e,t)=>{n.exports=function(n){var e=t.nc;e&&n.setAttribute("nonce",e)}},795:n=>{n.exports=function(n){if("undefined"==typeof document)return{update:function(){},remove:function(){}};var e=n.insertStyleElement(n);return{update:function(t){!function(n,e,t){var o="";t.supports&&(o+="@supports (".concat(t.supports,") {")),t.media&&(o+="@media ".concat(t.media," {"));var r=void 0!==t.layer;r&&(o+="@layer".concat(t.layer.length>0?" ".concat(t.layer):""," {")),o+=t.css,r&&(o+="}"),t.media&&(o+="}"),t.supports&&(o+="}");var a=t.sourceMap;a&&"undefined"!=typeof btoa&&(o+="\n/*# sourceMappingURL=data:application/json;base64,".concat(btoa(unescape(encodeURIComponent(JSON.stringify(a))))," */")),e.styleTagTransform(o,n,e.options)}(e,n,t)},remove:function(){!function(n){if(null===n.parentNode)return!1;n.parentNode.removeChild(n)}(e)}}}},589:n=>{n.exports=function(n,e){if(e.styleSheet)e.styleSheet.cssText=n;else{for(;e.firstChild;)e.removeChild(e.firstChild);e.appendChild(document.createTextNode(n))}}}},e={};function t(o){var r=e[o];if(void 0!==r)return r.exports;var a=e[o]={id:o,exports:{}};return n[o](a,a.exports,t),a.exports}t.n=n=>{var e=n&&n.__esModule?()=>n.default:()=>n;return t.d(e,{a:e}),e},t.d=(n,e)=>{for(var o in e)t.o(e,o)&&!t.o(n,o)&&Object.defineProperty(n,o,{enumerable:!0,get:e[o]})},t.o=(n,e)=>Object.prototype.hasOwnProperty.call(n,e),t.nc=void 0,(()=>{class n{constructor(e){if(n.instance)return n.instance;n.instance=this,this.databaseName=e,this.indexedDB=window.indexedDB||window.webkitIndexedDB,this.indexedDB||console.log("IndexedDB could not be found in this browser.")}openDatabase(){if(!this.indexedDB)return void console.log("IndexedDB not available.");const n=this.indexedDB.open(this.databaseName,1);return n.onerror=function(n){console.error("An error occurred with IndexedDB"),console.error(n)},n.onupgradeneeded=function(n){const e=n.target.result;e.objectStoreNames.contains("students")||e.createObjectStore("students",{keyPath:"id",autoIncrement:!0})},n}}const e=n,o=class{constructor(n,e,t,o){this.name=n,this.age=e,this.class=t,this.address=o}};var r=t(379),a=t.n(r),d=t(795),c=t.n(d),s=t(569),i=t.n(s),l=t(565),u=t.n(l),p=t(216),f=t.n(p),m=t(589),b=t.n(m),g=t(150),h={};h.styleTagTransform=b(),h.setAttributes=u(),h.insert=i().bind(null,"head"),h.domAPI=c(),h.insertStyleElement=f(),a()(g.Z,h),g.Z&&g.Z.locals&&g.Z.locals;const y=document.getElementById("add-student-btn"),x=document.getElementById("myModal"),v=document.getElementById("closeModalBtn"),w=document.getElementById("cancelStudentBtn"),E=document.getElementById("saveStudentBtn"),B=document.getElementById("deleteModal"),I=document.getElementById("confirmDeleteBtn"),k=document.getElementById("cancelDeleteBtn"),D=new e("studentDb");function C(){const n=D.openDatabase();n.onsuccess=function(){const e=n.result,t=e.transaction("students","readonly").objectStore("students"),o=[];t.openCursor().onsuccess=function(n){const t=n.target.result;t?(o.push(t.value),t.continue()):(function(n){const e=document.getElementById("studentTableBody");e.innerHTML="",n.forEach((n=>{const t=document.createElement("tr"),o=document.createElement("td");o.textContent=n.name;const r=document.createElement("td");r.textContent=n.age;const a=document.createElement("td");a.textContent=n.class;const d=document.createElement("td");d.textContent=n.address;const c=document.createElement("td"),s=document.createElement("button");s.style.background="#d9534f",s.style.color="#fff",s.style.borderRadius="5px",s.textContent="Delete",s.addEventListener("click",(()=>{var e;e=n.id,B.style.display="block",I.onclick=function(){!function(n){const e=D.openDatabase();e.onsuccess=function(){const t=e.result,o=t.transaction("students","readwrite"),r=o.objectStore("students").delete(n);r.onsuccess=function(){console.log(`Student with ID ${n} deleted from the database`),C()},r.onerror=function(e){console.error(`Error deleting student with ID ${n}:`,e.target.error)},o.oncomplete=function(){t.close()}}}(e),B.style.display="none"},k.onclick=function(){B.style.display="none"}})),c.appendChild(s),t.appendChild(o),t.appendChild(r),t.appendChild(a),t.appendChild(d),t.appendChild(c),e.appendChild(t)}))}(o),e.close())}}}y.addEventListener("click",(()=>{x.style.display="flex"})),v.addEventListener("click",(()=>{x.style.display="none"})),w.addEventListener("click",(()=>{x.style.display="none"})),E.addEventListener("click",(()=>{const n=document.getElementById("name").value,e=parseInt(document.getElementById("age").value),t=document.getElementById("class").value,r=document.getElementById("address").value;!function(n){const e=D.openDatabase();e.onsuccess=function(){const t=e.result,o=t.transaction("students","readwrite"),r=o.objectStore("students"),a=Date.now();r.put({id:a,...n}),o.oncomplete=function(){t.close(),console.log("Student added to the database :"+a)}}}(new o(n,e,t,r)),C(),document.getElementById("studentForm").reset(),document.getElementById("myModal").style.display="none"})),C()})()})();