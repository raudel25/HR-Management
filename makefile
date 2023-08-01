.PHONY: dev
dev:
	dotnet run --project HR-Management

.PHONY: restore
restore:
	dotnet restore

.PHONY: db
db:
	dotnet dotnet ef database update --project HR-Management

.PHONY: build
build:
	dotnet build