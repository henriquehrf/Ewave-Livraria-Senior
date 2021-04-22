FROM microsoft/mssql-server-linux:2017-latest

EXPOSE 1433

ENV ACCEPT_EULA=${ACCEPT_EULA:-Y}
ENV SA_PASSWORD=${SA_PASSWORD:-Cap1varaD@C3rrad@}
ENV DATABASE=${DATABASE:-ToDo}

COPY ./script/ /
ENTRYPOINT [ "/bin/bash", "./entrypoint.sh" ]
CMD [ "/opt/mssql/bin/sqlservr" ]