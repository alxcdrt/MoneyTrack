### Add migrations
`dotnet ef migrations add CreateDatabase --startup-project .\MoneyTrack.Api --project .\MoneyTrack.Infrastructure -o Data/Migrations --context MoneyTrackContext`

### Update database
`dotnet ef database update --startup-project .\MoneyTrack.Api --project .\MoneyTrack.Infrastructure --context MoneyTrackContext`
