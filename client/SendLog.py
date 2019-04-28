import requests
from requests.packages.urllib3.exceptions import InsecureRequestWarning
requests.packages.urllib3.disable_warnings(InsecureRequestWarning)
import json
import datetime
Log = {
 "Evento" : "Teste",
 "Etapa" : "python",
 "Inicio" : datetime.datetime.now().isoformat(),
 "FIm" : datetime.datetime.now().isoformat()
}
print(json.dumps(Log))
headers = { "Authorization" : "TOKEN",
            "content-type":"application/json" }
            
r = requests.post("https://localhost:44325/api/Logs",data=json.dumps(Log),headers=headers,verify=False)
print(r.content)