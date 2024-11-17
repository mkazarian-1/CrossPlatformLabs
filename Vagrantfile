# -*- mode: ruby -*-
# vi: set ft=ruby :

# Define the host IP addresses
hosts = {
  "ubuntu" => "192.168.56.10",
  "windows" => "192.168.56.11"
}

Vagrant.configure("2") do |config|
  # Common network configuration
  config.vm.network "public_network", bridge: "default"
  
  # BaGet URL as an environment variable for flexibility
  baget_url = "http://192.168.56.1:8080/v3/index.json"
  
  # Ubuntu Machine Configuration
  config.vm.define "ubuntu" do |ubuntu|
    ubuntu.vm.box = "bento/ubuntu-22.04"
    ubuntu.vm.hostname = "ubuntu-vm"
    ubuntu.vm.network "forwarded_port", guest: 7252, host: 7252
    ubuntu.vm.network "private_network", ip: hosts["ubuntu"]
    
    ubuntu.vm.provider "virtualbox" do |v|
      v.name = "Ubuntu VM"
      v.memory = "6048"
      v.cpus = 4
    end
    
    ubuntu.vm.synced_folder ".", "/home/vagrant/project"
    ubuntu.vm.provision "shell", path: "provision-ubuntu.sh", env: { BAGET_URL: baget_url }
  end

  # Windows Machine Configuration
  config.vm.define "windows" do |windows|
    windows.vm.box = "gusztavvargadr/windows-10"
    windows.vm.hostname = "windows-vm"
    windows.vm.network "private_network", ip: hosts["windows"]
    
    windows.vm.provider "virtualbox" do |v|
      v.name = "Windows VM"
      v.memory = "6096"
      v.cpus = 4
    end
    
    windows.vm.synced_folder ".", "C:/project"
    windows.vm.provision "shell", path: "provision-windows.sh", env: { BAGET_URL: baget_url }
  end
  
    config.vm.define "lab5" do |lab5|
      lab5.vm.box = "ubuntu/jammy64"
      lab5.vm.hostname = "lab5-vm"
      lab5.vm.network "public_network"
  	lab5.vm.network "forwarded_port", guest: 7128, host: 7128
      lab5.vm.network "forwarded_port", guest: 5165, host: 5165
      lab5.vm.provider "virtualbox" do |vb|
        vb.memory = "8192"
        vb.cpus = 4
      end
  
        # Provisioning for .NET installation on Ubuntu
      lab5.vm.provision "shell", inline: <<-SHELL
        # Update the system
        sudo apt-get update
        sudo apt-get install -y wget apt-transport-https
        # Install the Microsoft GPG key
        wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb
        sudo dpkg -i packages-microsoft-prod.deb
        # Install .NET SDK
        sudo apt-get update
        sudo apt-get install -y dotnet-sdk-8.0
        # Check the installation
        dotnet version
  
        #dotnet dev-certs https --trust
  
        #dotnet run --urls "https://0.0.0.0:7128"
      SHELL
  
      # Synced folder for Linux VM
      lab5.vm.synced_folder ".", "/home/vagrant/project"
    end
  
end
