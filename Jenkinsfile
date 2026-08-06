pipeline {
    agent {
        docker {
            image 'mcr.microsoft.com/dotnet/sdk:8.0'
        }
    }

    stages {
        stage('Restore') {
            steps {
                echo 'Restoring NuGet packages...'
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                echo 'Building .NET application...'
                sh 'dotnet build --no-restore'
            }
        }
    }
}