$Log = @{
 "Evento"= "Teste";
 "Etapa"= "powershell";
 "Inicio"= get-date -Format o;
 "FIm"= get-date -Format o;
}
$headers = @{ Authorization = "TOKEN" }
$Resposta = Invoke-WebRequest -Uri https://localhost:44325/api/Logs -Method POST -Body ($Log|ConvertTo-Json) -ContentType "application/json" -Headers $headers

echo $Resposta.Content