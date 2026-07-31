pipeline {
    agent any

    stages {

        stage('Clone') {
            steps {
                echo 'Repository already cloned by Jenkins.'
            }
        }

        stage('Show Files') {
            steps {
                sh 'pwd'
                sh 'ls'
            }
        }
    }
}