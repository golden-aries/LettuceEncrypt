# lettuceEncrypt
[github/natemcmaster/LettuceEncrypt](https://github.com/natemcmaster/LettuceEncrypt)

## Testing in Developtment
[Integration Testing](https://github.com/natemcmaster/LettuceEncrypt/tree/main/test/Integration)
Nate McMaster suggests:
Start ngrok by running ngrok http -bind-tls=false 5194. This will create a temporary, public URL http://TMP.ngrok.io
that is outdated use the following command instead:
ngrok http --scheme http 5194
Note: 5194 is a port assigned to http endpoint in MinimalApiDemo app in ./Properties/launchSettings.json

## Other ACME Clients
[ACME Client Implementations](https://letsencrypt.org/docs/client-options/)

[Automatic Certificate Management Environment (ACME)](https://www.rfc-editor.org/rfc/rfc8555)

[Automated Certificate Management Environment (ACME) TLS Application‑Layer Protocol Negotiation (ALPN) Challenge Extension](https://www.rfc-editor.org/rfc/rfc8737)

[wikepedia/acme](https://en.wikipedia.org/wiki/Automated_Certificate_Management_Environment)

## ALPN protocol issues
Cannot negotiate ALPN protocol "acme-tls/1" for tls-alpn-01 challenge, Code = Forbidden

### Verbose
fail: LettuceEncrypt.Internal.AcmeCertificateFactory[0]
      Failed to validate ownership of domainName 'eb44-2001-569-74ed-5e00-ab-54fd-786c-c710.ngrok.io'. Reason: urn:ietf:params:acme:error:unauthorized: Cannot negotiate ALPN protocol "acme-tls/1" for tls-alpn-01 challenge, Code = Forbidden
