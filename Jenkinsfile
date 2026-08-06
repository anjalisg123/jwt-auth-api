pipeline {
    agent any

    environment {
        DOCKER_IMAGE = 'anjali2802/jwt-auth-api'
    }

    stages {

        stage('Checkout') {
            steps {
                git branch: 'main',
                    url: 'https://github.com/anjalisg123/jwt-auth-api.git'
            }
        }

        stage('Restore & Build') {
            agent {
                docker {
                    image 'mcr.microsoft.com/dotnet/sdk:8.0'
                    reuseNode true
                }
            }

            steps {
                echo 'Restoring NuGet packages...'
                sh 'dotnet restore'

                echo 'Building .NET application...'
                sh 'dotnet build --no-restore'
            }
        }

        stage('Build Docker Image') {
            steps {
                echo 'Building Docker image...'

                sh '''
                    docker build \
                    -t $DOCKER_IMAGE:$BUILD_NUMBER \
                    -t $DOCKER_IMAGE:latest \
                    .
                '''
            }
        }

        stage('Push Docker Image') {
            steps {
                echo 'Pushing Docker image to Docker Hub...'

                withCredentials([
                    usernamePassword(
                        credentialsId: 'dockerhub-credentials',
                        usernameVariable: 'DOCKER_USERNAME',
                        passwordVariable: 'DOCKER_PASSWORD'
                    )
                ]) {
                    sh '''
                        echo "$DOCKER_PASSWORD" | docker login \
                        -u "$DOCKER_USERNAME" \
                        --password-stdin

                        docker push $DOCKER_IMAGE:$BUILD_NUMBER
                        docker push $DOCKER_IMAGE:latest

                        docker logout
                    '''
                }
            }
        }
    }
}