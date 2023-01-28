# Legal notice:
The code provided is for educational purposes only and should not be used for any malicious or illegal activities. Any unauthorized use of this code is strictly prohibited and violators will be held liable for their actions. The code is intended to be used solely for the purpose of learning and understanding vulnerabilities and should not be executed on any systems without proper authorization and oversight. The author of this code takes no responsibility for any actions taken by any party using this code and is not liable for any damages or harm caused as a result of its use.

# Why?
Recentlly, my friend noticed that when you get a strava.cz account, intentionally or not, username and password are the same - at least at the place we got our accounts from. Also, account's username is a number that goes up gradually - again, at least at the place we got our accounts from. We have tried "logging" into one of our friend's account, after beeing given permission prior. It worked. We wondered how many people did not change their default passwords (beeing same as given username). This tool is a proof of concept. I have not run, nor will I run this without gaining prior permision from user account owner. I have tested it using accounts of people that gave me explicit permission, plus my own newly created demo account.

# Possible fixes
1. The obvious one is to not allow username and password beeing same (After first login show users page to show their password or something...)
2. Implement two factor authentication
3. Instruct administrators of canteens to use randomly generated usernames and passwords
4. Place already existing bot/spam prevention solution in front of the website (eg. Cloudflare's WAF) 
5. Rate limit login attempts using fingerprinting - although this could be penetrated by randomly changing values used for said fingerprinting.
