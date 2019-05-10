import React, {Component} from 'react';
import{View, StyleSheet, Image, Text, TextInput, TouchableOpacity, AsyncStorage} from 'react-native';
import api from '../../services/api';
import jwt from 'jwt-decode';

class CadastrarTema extends Component{
    static navigationOptions={
        tabBarIcon: ({tintcolor}) =>{
            <Image
                source={require('../../assets/img/PlusIcon.png')}
                style={styles.iconeNavigatsrProj}
            />
        }
    }

    constructor(props){
        super(props);
        this.state ={
            Id: '',
            tema1: '',
            token: ""
        }
    }

    _cadastrar = async () => {

        const value = await AsyncStorage.getItem("userToken");

        await api.post("/tema", {
            tema1: this.state.tema1
        }, {
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": "Bearer " + value
                },


            });

    }

    render(){
        return(
            <View>
                <View style={styles.cabecalho}>
                    <Text style={styles.titulo}>Cadastro de tema</Text>
                    <View style={styles.linhaTitulo} />
                </View>
                <TextInput style = {styles.input} 
                    autoCapitalize="none"
                    returnKeyType="next" 
                    placeholder='Nome do tema' 
                    onChangeText={tema1 => this.setState({ tema1 })}
                    placeholderTextColor='rgb(161, 162, 163)'/>

                <TouchableOpacity style={styles.buttonContainer}
                onPress={this._cadastrar}
                >
                            <Text  style={styles.buttonText}>Confirmar</Text>
                </TouchableOpacity>     
            </View>
        );
    }
}

const styles = StyleSheet.create({
    iconeNavigatorProj: {width: 25,
        height: 25,
        tintColor: "white"},
        container: {
            padding: 20
           },
           input:{
               height: 40,
               backgroundColor: 'rgba(225,225,225,0.2)',
               marginBottom: 10,
               padding: 10,
               color: 'red',
               width: 376,
               marginLeft: 16
           },
           buttonContainer:{
               backgroundColor: '#2980b6',
               paddingVertical: 15,
               width: 300,
               marginLeft: 55
           },
           buttonText:{
               color: '#fff',
               textAlign: 'center',
               fontWeight: '700'
           },
           titulo: {
            fontSize: 16,
            letterSpacing: 1
        },
        cabecalho: {
            flex: 1,
            justifyContent: "center",
            alignItems: "center",
            marginTop: 30,
            marginBottom:30
        },
    
          linhaTitulo:{
            width: 100,
            borderBottomColor: "#999999",
            borderBottomWidth: 0.9,
            marginBottom: 8,
            marginTop: 2
        }
});

export default CadastrarTema;