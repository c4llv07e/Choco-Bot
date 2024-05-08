# ���������� ������� ����� � .NET Core SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# ������������� ������� ����������
WORKDIR /app

# ����������� ��������� ���� � �������������� �������, ������ ����������
COPY . ./
RUN dotnet restore && \
    dotnet publish -c Release -o out

# ������� ��������� ����� �� ������ .NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# ������������� ������� ����������
WORKDIR /app

# �������� ��������� ���������� �� ������ ������
COPY --from=build-env /app/out .

# ������� ������������ � ������������� �������
RUN useradd -m choco && \
    chown -R choco:choco /app
USER choco

# ��������� ���� ��� ����������
EXPOSE 80

# ��������� ����������
ENTRYPOINT ["dotnet", "Choco.dll"]