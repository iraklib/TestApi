# TestApi
### Test CancelationToken
### https://localhost:7175/Home/GetCompanyWithTimeout მეთოდის გამოძახებისისას https://localhost:7219/api/Service/{companyName}-ს გადაეცემა CancellationToken.
### სერვისის გამოძახებისას Timeout-ის დაყენება შესაძლებელია HttpClient-ზე:
### HttpClient _httpClient = new HttpClient
### {
###     BaseAddress = new Uri("https://localhost:7219"),
###     Timeout = new TimeSpan(0, 0, 10)
### };
### ან შესაძლებელია CancellationToken-ს დაუყენედეს Timeout მნიშვნელობა:
### var cancellationTokenSource = new CancellationTokenSource();
### cancellationTokenSource.CancelAfter(2000);
